using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;
    public GameObject Bullet;
    public GameObject BulletSource;
    
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public PlayerData GetData()
    {
        var pos = this.transform.position;
        var rot = this.transform.rotation;
        PlayerData pd = new PlayerData();
        pd.Position = pos;
        pd.Rotation = rot;
        return pd;
    }
	// Use this for initialization
	void Start () {
	}
	/// <summary>
    /// Pega a rotação e translação que o jogador quer, baseado nos controles.
    /// </summary>
    /// <param name="translation"></param>
    /// <param name="rotation"></param>
    private void GetInputData(ref float translation, ref float rotation)
    {
        translation = Input.GetAxis("Vertical") * Speed;
        rotation = Input.GetAxis("Horizontal") * RotationSpeed;
    }
    /// <summary>
    /// Retorna true se a spacebar tá pressionada
    /// </summary>
    /// <returns></returns>
    private bool IsSpacebarPressed()
    {
        if (Input.GetKeyDown("space"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Movimenta o jogador de acordo com o input dos direcionais
    /// </summary>
    private void MovePlayer()
    {
        float translation = 0; float rotation = 0;
        GetInputData(ref translation, ref rotation);
        translation = translation * Time.deltaTime;
        rotation = rotation * Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
    //Se o cara pressionou espaço, deve fazer os rituais de tiro
    private void VerifyShooting()
    {
        bool hasPressedSpace = IsSpacebarPressed();
        if (hasPressedSpace)
        {
            var newBullet = Object.Instantiate(Bullet,BulletSource.transform.position, Quaternion.identity);
            newBullet.GetComponent<BulletController>().SetDirection(transform.forward);
        }
    }

    // Update is called once per frame
    void Update () {
        MovePlayer();
        VerifyShooting();
	}
}
