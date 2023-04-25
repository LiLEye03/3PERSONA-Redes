using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using StarterAssets;
using Cinemachine;
using UnityEngine.Rendering;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private GameObject virtualcamprefab;
    Vector3 mousePos= Vector3.zero;
    StarterAssetsInputs inputs;
    public ThirdPersonController tpc;
    // Start is called before the first frame update

    void Start()
    {
        tpc = GetComponent<ThirdPersonController>();
        inputs = GetComponent<StarterAssetsInputs>();
        CreateCinemachine();
    }
    void OnNetworkSpawnOverRide()
    {
        tpc = GetComponent<ThirdPersonController>();
        inputs = GetComponent<StarterAssetsInputs>();
    }
    // Update is called once per frame
    void Update()
    {
        //if (!IsOwner) return;
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            // transform.position += new Vector3(0,0,1)*Time.deltaTime*6;
            //inputs.MoveInput(new Vector2(0,1));
        }
        inputs.MoveInput(new Vector2(movex, movey));


        tpc.JumpAndGravity();
        tpc.GroundedCheck();
        tpc.Move();
        if (Input.GetButtonDown("Jump"))
            inputs.jump = true;
        if (Input.GetButton("Fire3"))
        {
            inputs.sprint = true;
        }
        else
        {
            inputs.sprint = false;
        }
    }
    void LateUpdate()
    {
        if (IsOwner)
        {     
        tpc.CameraRotation();
        }
    }
    void CreateCinemachine()
    {
        
        var camplayerinstance = Instantiate(virtualcamprefab.GetComponent<Cinemachine.CinemachineVirtualCamera>());
        camplayerinstance.gameObject.name = "camv " + OwnerClientId;

        camplayerinstance.Follow = gameObject.transform.GetChild(0);
        camplayerinstance.LookAt = gameObject.transform.GetChild(0); 
    }

    private void FixedUpdate()
    {
        Vector3 deltamouse= mousePos - Input.mousePosition;
       mousePos= Input.mousePosition;
       inputs.LookInput(new Vector2(deltamouse.x, deltamouse.y));
    }
}
