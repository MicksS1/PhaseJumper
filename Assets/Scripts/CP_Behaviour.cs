using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP_Behaviour : MonoBehaviour
{
    public GameObject Player;
    public GameObject CPoint;
    public Animator CPAnim;
    public Transform pos;
    public PMove PMove;
    public SaveManager SaveManager;
    private Vector2 CPPos;
    public Vector2 newPos;
    private Vector2 orPos;
    public Vector2 startPos;
    public float newX;
    public float newY;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PMove>();
        SaveManager = GameObject.FindGameObjectWithTag("SaveController").GetComponent<SaveManager>();

        if (SaveManager.loadSave == 1)
        {
            SaveManager.LoadData();
            Debug.Log("jalans");
            Player.transform.position = SaveManager.CP.startPos;
            //  ^ini harus SaveManager.CP.startPos, gbs startpos doang gtw knp alSKdhjkljashd
        }

        Debug.Log("start:" + startPos);
        orPos = Player.transform.position;
        CPPos = orPos;
    }

    // Update is called once per frame
    void Update()
    {
        newX = PlayerPrefs.GetFloat("CheckpointX");
        newY = PlayerPrefs.GetFloat("CheckpointY");

        CPPos = new Vector2(newX, newY);
        newPos = new Vector2(newX, newY + 1);

        if (Player.activeSelf == false)
        {
            PMove.deaths++;
            Player.transform.position = newPos;
            Player.SetActive(true);

            AudioManager.instance.playSfx("Dead");
        }

        if (CPoint.transform.position.Equals(CPPos) == false)
            CPAnim.SetTrigger("GoInactive");
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            CPAnim.SetTrigger("GoActive");

            PlayerPrefs.SetFloat("CheckpointX", pos.position.x);
            PlayerPrefs.SetFloat("CheckpointY", pos.position.y);

            SaveManager.SaveData();
        }
    }

    public void GoToCheckpoint()
    {
        Player.transform.position = newPos;
    }

    public void GoToStart()
    {
        Player.transform.position = orPos;
    }

    public void ResetCP()
    {
        PlayerPrefs.SetFloat("CheckpointX", orPos.x);
        PlayerPrefs.SetFloat("CheckpointY", orPos.y);
    }
}
