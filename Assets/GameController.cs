using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO: Se o jogador não informou o nome, bloqueia a jogabilidade.
public class GameController : MonoBehaviour {
    public PlayerController Player;
    public string CurrentState = "not logged";
    public Button LoginButton;
	void Start () {
        LoginButton.onClick.AddListener(() =>
        {
            //TODO: login no servidor e tal. USAR ASYNC
            //...
            CurrentState = "logged";
        });
	}

	void ControlIfPlayerIsEnabled()
    {
        if (CurrentState == "not logged")
        {
            Player.Disable();
        }
        if (CurrentState == "logged")
        {
            Player.Enable();
        }

    }

    void Update () {
        ControlIfPlayerIsEnabled();
        //TODO: Mandar pro servidor e pegar o status atual

    }
}
