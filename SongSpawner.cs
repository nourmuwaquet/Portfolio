using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SongSpawner : MonoBehaviour
{
    [SerializeField] float bpm;
    [SerializeField] GameObject riseAttackObject;
    [SerializeField] GameObject dropAttackObject;
    [SerializeField] GameObject needleObject;
    [SerializeField] GameObject burst;
    [SerializeField] GameObject player;



    float timePerBeat;
    void Start()
    {
        StartCoroutine("Song");
        timePerBeat = 60 / bpm;
        Debug.Log("Time per beat" + timePerBeat);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Song()
    {
        yield return new WaitForSeconds(2.8f);
        for (int x = 0; x <= 15; x++)
        {
            dropAttack();
            yield return new WaitForSeconds(timePerBeat);
        }
        for (int x = 0; x <= 15; x++)
        {
            riseAttack();
            yield return new WaitForSeconds(timePerBeat);
        }
        riseStaircase(8, false);
        yield return new WaitForSeconds(timePerBeat);
        riseStaircase(8, true);
    }

    void riseAttack ()
    {
            GameObject.Instantiate(riseAttackObject, new Vector3(player.transform.position.x, -5.6f, 0f), Quaternion.Euler(0, 0, 180));
    }
    void dropAttack()
    {
        GameObject.Instantiate(dropAttackObject, new Vector3(player.transform.position.x, 5.6f, 0f), Quaternion.identity);
    }
    void riseStaircase(int times, bool reverse)
        {
            StartCoroutine(Staircase(times, reverse));
        }
    void needleAttack(int needleAngle)
    {

    }

    IEnumerator Staircase(int times, bool reverse)
    {
        for (int x = 0; x <times;x++)
        {
            if (reverse == false)
                GameObject.Instantiate(riseAttackObject, new Vector3(-8.5f+(x*2f), -5.6f, 0f), Quaternion.Euler(0, 0, 180));
            else
                GameObject.Instantiate(riseAttackObject, new Vector3(5.5f + (x * -2f), -5.6f, 0f), Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(timePerBeat / times);
        }
    }
}
