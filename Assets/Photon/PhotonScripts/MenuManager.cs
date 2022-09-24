using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Menu[] allMenu;
    [SerializeField] private InputField createInput;
    [SerializeField] private InputField joinInput;

    public void OpenMenu(int menu_id){
        for(int i = 0; i < allMenu.Length; i++){
            if (i == menu_id){
                allMenu[menu_id].Open();
            }else{
                allMenu[i].Close();
            }
        }
    }

    public void CreateRoom(){
        if(!string.IsNullOrEmpty(createInput.text)){
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        }
    }

    public void JoinRoom(){
        if(string.IsNullOrEmpty(joinInput.text)){
            PhotonNetwork.JoinRoom(joinInput.text); 
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print(message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print(message);
    }
}
