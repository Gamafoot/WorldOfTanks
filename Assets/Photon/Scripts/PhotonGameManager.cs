using UnityEngine.SceneManagement;
using Photon.Pun;

public class PhotonGameManager : MonoBehaviourPunCallbacks
{
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Menu");
    }
}
