using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WorkerControl : MonoBehaviour
{

    //enum���� ����
    public enum botState
    {
        Move,
        Tie,
        SlowDown,
        Die
    }

    //ó�� ����
    public botState nowstate = botState.Move;
    private bool isDead = false;

    private Transform botTr;
    private Transform playerTr;
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject gameEndUI;
    IEnumerator botAni;


    //�ִϸ����� ���ڿ� Hash
    private readonly int hasDead = Animator.StringToHash("isDead");
    private readonly int hasTrace = Animator.StringToHash("isTrace");
    private readonly int hasSlow = Animator.StringToHash("isSlow");
    private readonly int hasTie = Animator.StringToHash("isTie");

    void Start()
    {
        botTr = GetComponent<Transform>();
        //playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nowstate = botState.Move;
        botAni = BotAni();
    }

    void Update()
    {
        if (playerTr == null && isDead == false)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                playerTr = GameObject.FindWithTag("Player").transform;
                StartCoroutine(botAni);
            }
        }
        else
        {
            if (agent.enabled == true)
            {
                agent.destination = playerTr.position;
            }
        }
    }


    //Ʈ���� ó��: 3�� ������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.SetActive(false);

        if (other.gameObject.tag == "tieItem")
        {
            Debug.Log("Tie");
            nowstate = botState.Tie;
            agent.enabled = false;
        }
        else if (other.gameObject.tag == "slowItem")
        {
            nowstate = botState.SlowDown;
            agent.enabled = false;
        }
        else if (other.gameObject.tag == "dieItem" || other.gameObject.tag == "Landmine")
        {
            nowstate = botState.Die;
        }
        else if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            nowstate = botState.Die;
        }
    }

    //�浹ó��: �÷��̾�, ��, �Ѿ�
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")//�÷��̾� Die ����
        {
            collision.gameObject.SetActive(false);
            gameEndUI.SetActive(true);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            nowstate = botState.Die;
        }
    }

    //���¿� ���� �ִϸ��̼�
    public IEnumerator BotAni()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(10.0f);
        Debug.Log("Test0");
        while (!isDead && playerTr != null && botTr != null)
        {
            Debug.Log("Test1");
            switch (nowstate)
            {
                case botState.Move:
                    anim.SetBool(hasTrace, true);
                    anim.SetBool(hasTie, false);
                    anim.SetBool(hasSlow, false);
                    break;

                case botState.Tie:
                    anim.SetBool(hasSlow, false);
                    anim.SetBool(hasTie, true);
                    break;

                case botState.SlowDown:
                    Debug.Log("Test2");
                    anim.SetBool(hasSlow, true);
                    anim.SetBool(hasTie, false);
                    yield return waitForSeconds;
                    agent.enabled = true;
                    nowstate = botState.Move;
                    break;

                case botState.Die:
                    anim.SetBool(hasDead, true);
                    isDead = true;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
