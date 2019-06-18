using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipemanager : MonoBehaviour
{
    public GameObject tamplate;

    List<Pipeline> Pipelines = new List<Pipeline>();
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine1 = null;

    public void Init()
    {
        for (int i = 0; i < Pipelines.Count; i++)
        {
            Destroy(Pipelines[i].gameObject);
        }
        Pipelines.Clear();
    }

    public void StartRun()
    {
        coroutine1 = StartCoroutine(GeneratePipeLines());
    }

    public void StopRun()
    {
        StopCoroutine(coroutine1);
        for (int i = 0; i < Pipelines.Count; i++)
        {
            Pipelines[i].enabled = false;
        }
    }

    IEnumerator GeneratePipeLines()
    {
        for(int i=0;i<3;i++)
        {
            if(Pipelines.Count<3)
            Generatepipeline();
            else
            {
                Pipelines[i].enabled = true;
                Pipelines[i].Init();
            }
            yield return new WaitForSeconds(2.3f);
        }
    }

    void Generatepipeline()
    {
        if (Pipelines.Count < 3)
        {
            GameObject obj = Instantiate(tamplate,this.transform);
            Pipeline p = obj.GetComponent<Pipeline>();
            Pipelines.Add(p);
        }
       
    }
}
