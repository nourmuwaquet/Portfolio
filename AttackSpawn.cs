using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawn : MonoBehaviour
{
    float timer;
    bool beginSong = false;
    [SerializeField] GameObject DropAttack;
    [SerializeField] GameObject RiseAttack;
    [SerializeField] GameObject Needle;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        if (!beginSong)
        {
            StartCoroutine("Song");
            beginSong = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer == 2.878038)
            GameObject.Instantiate(DropAttack, new Vector3(player.transform.position.x, 5.5f, 0f), Quaternion.identity);
    }

    IEnumerator Song()
    {
        float waitTime = 0;
        float currentTime = 2.8f;
        yield return new WaitForSeconds(currentTime);
        GameObject.Instantiate(DropAttack, new Vector3(player.transform.position.x, 5.6f, 0f), Quaternion.identity);
        waitTime = 3.79f - currentTime;
        currentTime = 3.7f;
        yield return new WaitForSeconds(waitTime);
        GameObject.Instantiate(DropAttack, new Vector3(player.transform.position.x, 5.6f, 0f), Quaternion.identity);
        waitTime = 4.6f - currentTime;
        currentTime = 4.6f;
        yield return new WaitForSeconds(waitTime);
        GameObject.Instantiate(DropAttack, new Vector3(player.transform.position.x, 5.6f, 0f), Quaternion.identity);
        waitTime = .918f;
        for (int x = 0; x <= 12; x++)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject.Instantiate(DropAttack, new Vector3(player.transform.position.x, 5.6f, 0f), Quaternion.identity);
        }
        waitTime = .938f;
        for (int y = 0; y <= 14; y++)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject.Instantiate(RiseAttack, new Vector3(player.transform.position.x, -5.6f, 0f), Quaternion.Euler(0,0,180));
        }
        yield return new WaitForSeconds(waitTime+1f);
        waitTime = .2f;
        for (int z = 0; z<=5;z++)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject.Instantiate(RiseAttack, new Vector3(-8.5f+2.5f*z, -5.6f, 0f), Quaternion.Euler(0, 0, 180));
        }
        for (int x = 0; x <= 5; x++)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject.Instantiate(RiseAttack, new Vector3(6.5f - 2.5f * x, -5.6f, 0f), Quaternion.Euler(0, 0, 180));
        }
        waitTime = .938f;
        yield return new WaitForSeconds(waitTime);
        for (int x = 0; x <= 4; x++)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject.Instantiate(DropAttack, new Vector3(player.transform.position.x, 5.6f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            GameObject.Instantiate(RiseAttack, new Vector3(6.5f - 2.5f * x, -5.6f, 0f), Quaternion.Euler(0, 0, 180));
        }
        yield return new WaitForSeconds(waitTime);
        GameObject.Instantiate(Needle, new Vector3(-7f, -4.6f, 0f), Quaternion.Euler(0, 0, 0));
        GameObject.Instantiate(Needle, new Vector3(6f, -4.6f, 0f), Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(waitTime*1.5f);
        GameObject.Instantiate(Needle, new Vector3(-3f, 4.6f, 0f), Quaternion.Euler(0, 0, 180));
        GameObject.Instantiate(Needle, new Vector3(2f, 4.6f, 0f), Quaternion.Euler(0, 0, 180));
        yield return new WaitForSeconds(waitTime * 2f);
        GameObject.Instantiate(Needle, new Vector3(-.5f, 4.6f, 0f), Quaternion.Euler(0, 0, 180));
        yield return new WaitForSeconds(waitTime * 3f);
        StartCoroutine("RemoveNeedles");
        yield return new WaitForSeconds(waitTime);
        GameObject.Instantiate(Needle, new Vector3(5f, 4.6f, 0f), Quaternion.Euler(0, 0, 120));
        GameObject.Instantiate(Needle, new Vector3(2.6f, -4.6f, 0f), Quaternion.Euler(0, 0, 66));
        yield return new WaitForSeconds(waitTime*2.2f);
        GameObject.Instantiate(Needle, new Vector3(-8.4f, 4.6f, 0f), Quaternion.Euler(0, 0, -160));
        GameObject.Instantiate(Needle, new Vector3(.4f, 4.6f, 0f), Quaternion.Euler(0, 0, -212));
        yield return new WaitForSeconds(waitTime * 3f);
        StartCoroutine("RemoveNeedles");
        yield return new WaitForSeconds(waitTime);

    }

    IEnumerator RemoveNeedles()
    {
        GameObject[] needles = GameObject.FindGameObjectsWithTag("Needle");

        for (int x = 0; x < needles.Length; x++)
        {
            StartCoroutine("FadeAway",needles[x]);
        }
        yield return new WaitForSeconds(.945f);

        for (int x = 0; x<needles.Length; x++)
        {
            Destroy(needles[x]);
        }
    }

    IEnumerator FadeAway(GameObject gameObject)
    {
        for (int y = 0; y <= 10; y++)
        {
            SpriteRenderer sprite;
            yield return new WaitForSeconds(.04f);
            sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, 1 - y * .1f);
        }
    }
}
