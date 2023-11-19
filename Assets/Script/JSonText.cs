using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class JSonText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI jsonText;
    IEnumerator StartJson()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://catfact.ninja/fact"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                JObject o = JObject.Parse(request.downloadHandler.text);
                jsonText.text = o["fact"].ToString();
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