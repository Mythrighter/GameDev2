using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCube : MonoBehaviour
{
    private Coroutine first;
    
    // Start is called before the first frame update
    void Start()
    {
        first = StartCoroutine(EpicCoroutine());
        StartCoroutine(SuperCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    IEnumerator EpicCoroutine()
    {
        //How long to wait for.
        float end_time = Time.time + 5;

        //Step 1: Rotate along the Y axis for 5 seconds.
        while(Time.time < end_time)
        {
            //Rotate.
            transform.Rotate(Vector3.up * Time.deltaTime * 60, Space.World);

            //Cause coroutine to wait until the next frame.
            yield return null;
        }

        //yield break; //How to stop a Coroutine mid-routine.

        //Step 2: Change color to red and wait for 2 seconds.
        GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(2);

        //Step 3: Rotate on the X axis for 5 seconds.
        end_time = Time.time +3;
        while (Time.time < end_time)
        {
            //Rotate.
            transform.Rotate(Vector3.left * Time.deltaTime * 60, Space.World);

            //Cause coroutine to wait until the next frame.
            yield return null;
        }

        //Step 4: Change color to yellow and wait for 2 seconds.
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(2);

        //Step 5: Scale down over 1 second.
        end_time = Time.time + 1f;
        while (Time.time < end_time)
        {
            //Scale.
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime;

            //Cause coroutine to wait until the next frame.
            yield return null;
        }

        //Step 6: Change color to blue and wait for 2 seconds.
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(0.5f);

        //Step 7: Scale up over 1 second.
        end_time = Time.time + 1f;
        while (Time.time < end_time)
        {
            //Scale.
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime;

            //Cause coroutine to wait until the next frame.
            yield return null;
        }

        //Final step.
        GetComponent<MeshRenderer>().material.color = Color.green;
        Debug.Log("Finished Epic Coroutine!");
    }

    IEnumerator SuperCoroutine()
    {
        float end_time = Time.time + 5f;
        while (Time.time < end_time)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 60, Space.World);
            yield return null;
        }

        Debug.Log("Super Coroutine is finished!");

        //StopCoroutine(first); //How to stop another Coroutine within this one.
    }
}
