using Gameplay.ShipSystems;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;

namespace Gameplay.ShipControllers.CustomControllers
{
    
    public class PlayerShipController : ShipController
    {
        float pointrot = 0f;
        bool MouseHeel=false;
        private Vector3 dir; private float angleTarget;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Text _text;
        [SerializeField] private Text _text2;
        [SerializeField]
        private Text _text3;
        [SerializeField]
        private Text _text4;
        Vector2 _moveDirection;
        Vector2 _mouseDirection;
        private bool isDown0 = false, isDown1=false;
        [SerializeField]InputAction.CallbackContext contextDown;
        public void OnM(InputAction.CallbackContext context)
        {
            if (context.action.name == "M")
            {
                MouseHeel = true;
            }
        }
        public void OnN(InputAction.CallbackContext context)
        {
            if (context.action.name == "N")
            {
                MouseHeel = false;
            }
        }
        public void OnDown0(InputAction.CallbackContext context)
        {
            isDown0 = context.action.IsPressed();
        }
        public void OnDown1(InputAction.CallbackContext context)
        {
            isDown1 = context.action.IsPressed();
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }
        public void OnMouse(InputAction.CallbackContext context)
        {
            _mouseDirection = context.ReadValue<Vector2>();
        }
        private void Awake()
        {
            _playerInput = new PlayerInput();
        }
        private void CalculateAngle(Vector3 temp)
        {
            dir = new Vector3(temp.x, transform.position.y, temp.z) - transform.position;
            angleTarget = Vector3.Angle(dir, transform.forward);
        }
        private Quaternion LookAtThis(Vector3 target)
        {
            //if (target != lastTarget)
            //{
            CalculateAngle(target);
            return Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), 220);
            //}
        }
        private Vector3 inputRotation;
        private Vector3 mousePlacement;
        private Vector3 screenCentre;
        void FindCrap()
        {
            screenCentre = new Vector3(Screen.width * 0.5f, 0, Screen.height * 0.5f);
            mousePlacement = _mouseDirection;
            mousePlacement.z = mousePlacement.y;
            mousePlacement.y = 0;
            inputRotation = mousePlacement - screenCentre;
        }
        float yrot = 0;
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            if(
               transform.position.x<GetComponent<CollShip>().limitx||
               transform.position.x>GetComponent<CollShip>().limitx1
               )
            {
                if (_moveDirection.y < 0) { return; }
                pointrot += _moveDirection.x * Time.deltaTime * -100;
                movementSystem.LateralRotate(pointrot);
                if (transform.position.y > 21) { transform.position = new Vector3(transform.position.x, -18, 0); }
                if (transform.position.y < -21) { transform.position = new Vector3(transform.position.x, 19, 0); }
                if (MouseHeel)
                {
                    FindCrap();
                    var rot = Quaternion.LookRotation(inputRotation);
                    yrot = rot.y;
                    transform.rotation = Quaternion.Euler(0, 0, yrot * -100);
                }
                movementSystem.LongMovement(_moveDirection.y * Time.deltaTime);

            }
            if(
               transform.position.x > GetComponent<CollShip>().limitx)
            {
                //print("x");
                transform.position = new Vector3(GetComponent<CollShip>().limitx1 + 2, transform.position.y, transform.position.z);
            }
           
            if(transform.position.x < GetComponent<CollShip>().limitx1
               )
            {
                //print("x1");
                transform.position = new Vector3(GetComponent<CollShip>().limitx-2, transform.position.y, transform.position.z);
            }

        }
        protected int countlaser;bool blocked = false;
        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            _text.text = countlaser.ToString();
            _text2.text = transform.rotation.z.ToString();
            _text3.text = transform.position.x.ToString();
            _text4.text = transform.position.y.ToString();
            if (isDown0)//Input.GetKey(KeyCode.Space)|| Input.GetMouseButton(0))
            {
                fireSystem.TriggerFire();
                var source = GetComponent<AudioSource>();
                if(source !=null)source.PlayOneShot(source.clip);
            }
            if (isDown1)//Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || Input.GetMouseButton(1))
            {
                if (countlaser > 150||blocked) { blocked = true;
                    fireSystem.TriggerFire();
                    var source2 = GetComponent<AudioSource>();
                    if (source2 != null) source2.PlayOneShot(source2.clip);
                    return; }
                fireSystem.TriggerLaser();countlaser++;
                var source = GetComponent<AudioSource>();
                if (source != null) source.PlayOneShot(source.clip);
            }
            else
            {
                if (countlaser < 50)
                {
                    blocked = false;
                }
                if (countlaser >= 0) countlaser--; 
            }
            //if (Input.GetKey(KeyCode.M))
            //{
            //    MouseHeel = true;
            //}
            //if (Input.GetKey(KeyCode.N))
            //{
            //    MouseHeel = false;
            //}
        }
       
    }
}
