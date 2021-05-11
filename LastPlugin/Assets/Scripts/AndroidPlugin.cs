using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AndroidPlugin : MonoBehaviour
{
    private AndroidJavaObject kotlin;

    private (Texture2D _tex, Sprite _spr) CallBack = (null, null);

    private void Awake()
    {
        kotlin = new AndroidJavaObject("com.unity3d.player.unityGallery");
    }

    public IEnumerator ShowGallery(UnityAction<Texture2D, Sprite> val)
    {
        Debug.Log("갤러리 open 시작");

        kotlin.Call("Open");

        yield return new WaitUntil(() => CallBack._tex != null && CallBack._spr != null);
        val(CallBack._tex, CallBack._spr);

        Debug.Log("이미지 넘겨주기 완료");


    }

    private void getImage(string path)
    {
        Debug.Log("Get이미지 시작");
        WWW www = new WWW($"file://{path}");
        Debug.Log("find path OK!");

        var _tex = www.texture;
        var _spr = Sprite.Create(_tex, new Rect(0f, 0f, _tex.width, _tex.height), new Vector2(0.5f, 0.5f), 100);

        Debug.Log("image Create  OK!");
        CallBack = (_tex, _spr);
        Debug.Log("image Loading OK!");

    }
}
