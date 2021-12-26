using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Weapons
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField]
        private ProjectilePool _projectile;
        [SerializeField]
        private ProjectilePool _laser;
        [SerializeField]
        private ProjectilePool[] projectiles;
        int wpnum;
        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _cooldown;


        private bool _readyToFire = true;
        private UnitBattleIdentity _battleIdentity;
        PlayerInput _playerInput;
        public void OnQ(InputAction.CallbackContext context)
        {
            //wpnum++;
            //if (projectiles.Length < wpnum || wpnum < 0)
            //{
            //    wpnum = 0;
            //}
        }
        public void OnE(InputAction.CallbackContext context)
        {
            //wpnum--;
            //if (projectiles.Length < wpnum || wpnum < 0)
            //{
            //    wpnum = 0;
            //}
        }
        public void Update()
        {
            
        }
        public void newCooldown()
        {
            //_cooldown = 0.33f;
            Invoke("old", 8.0f);
        }
        private void old()
        {
            _cooldown = 0.1f;
        }
        public void setwp2()
        {
            wpnum = 2;
        }
        public void setwp()
        {
            wpnum = 1;
        }
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }

        bool isplayer = false;
        public void setpl1()
        {
            isplayer = true;
        }
        public void TriggerFire()
        {
            if (!_readyToFire)
                return;
            _projectile = projectiles[wpnum];
            var proj = Instantiate(_projectile, transform.position, transform.rotation);
            proj.Init(_battleIdentity);
            if (isplayer) { proj.tag = "Player"; PoolManager.GetObject(proj.gameObject.name, proj.gameObject.transform.position, proj.gameObject.transform.rotation); proj.GetComponent<SpriteRenderer>().color = Color.green; }
            StartCoroutine(Reload(_cooldown));
        }
        public void TriggerLaser()
        {
            if (!_readyToFire)
                return;
            _projectile = projectiles[wpnum];
            var proj = Instantiate(_laser, _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            if (isplayer) { proj.tag = "laser"; PoolManager.GetObject(proj.gameObject.name, proj.gameObject.transform.position, proj.gameObject.transform.rotation); proj.GetComponent<SpriteRenderer>().color = Color.green; }
            StartCoroutine(Reload(_cooldown));
        }

        private IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }

    }
}
