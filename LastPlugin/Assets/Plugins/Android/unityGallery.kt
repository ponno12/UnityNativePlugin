package com.unity3d.player
import android.app.Activity
import android.content.Intent
import android.net.Uri
import android.provider.MediaStore
import com.unity3d.player.UnityPlayer
import com.unity3d.player.UnityPlayerActivity

class unityGallery : UnityPlayerActivity(){

    fun Open(){
        val intent = Intent(Intent.ACTION_PICK,MediaStore.Images.Media.INTERNAL_CONTENT_URI)
        println("intnet값")
        UnityPlayer.currentActivity.startActivityForResult(intent,1);
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent) {
        super.onActivityResult(requestCode, resultCode, data)
        println("onActivityResult 실행")
        if(requestCode == 1 && resultCode == Activity.RESULT_OK){
            val Upath = data!!.data;
            val path =abs_path(Upath!!)
            //유니티에 값을 전달
            UnityPlayer.UnitySendMessage("AndroidPlugin","getImage",path)
        }
    }
    //절대경로 바꿔주는 함수
    fun abs_path(uri:Uri): String?{
        val m_data = arrayOf(MediaStore.Images.Media.DATA)
        val cursor = managedQuery(uri,m_data,null,null,null)
        startManagingCursor(cursor)
        val columIndex = cursor.getColumnIndexOrThrow(MediaStore.Images.Media.DATA)
        cursor.moveToFirst()
        return cursor.getString(columIndex)
    }
}