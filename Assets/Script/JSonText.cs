using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class JSonText : MonoBehaviour
{
    IEnumerator StartJson()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://catfact.ninja/fact"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                JObject o = JObject.Parse(request.downloadHandler.text);
                Debug.Log(o["fact"].ToString());
            }
        }
    }
    private void Start()
    {
        StartCoroutine(StartJson());
    }
    public void NewFact()
    {
        StartCoroutine(StartJson());
    }
}