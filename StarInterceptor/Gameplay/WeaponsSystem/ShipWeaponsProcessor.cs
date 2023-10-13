using StarInterceptor.Core.Processors;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Engine.Events;
using Stride.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;

namespace StarInterceptor.Gameplay.WeaponsSystem
{
    public class ShipWeaponsProcessor : SimpleEntityProcessor<WeaponLoadoutState>
    {
        public WeaponsRegistry WeaponsRegistry { get; set; }

        private bool _mainWeaponSet = false;
        private Weapon _selectedMainWeapon;

        private EventReceiver<WeaponSlot> _weaponFireEventReceiver = new EventReceiver<WeaponSlot>(ShipWeaponsEventRegistry.ShipWeaponsFiredEvent);

        public ShipWeaponsProcessor(WeaponsRegistry weaponsRegistry)
        {
            WeaponsRegistry = weaponsRegistry;
        }

        public override void Update(GameTime time)
        {
            if (ComponentDatas.Count() == 1)
            {
                WeaponLoadoutState weaponLoadoutState = ComponentDatas.First().Key;
                SetCurrentWeapons(weaponLoadoutState);
                Log.Debug($"Main weapon is set to: {_selectedMainWeapon.Id}");

                UpdateWeaponsPauseTimer(time, weaponLoadoutState);
                if (_weaponFireEventReceiver.TryReceive(out WeaponSlot weaponSlotFired))
                {
                    FireWeapons(time, weaponLoadoutState, weaponSlotFired);
                }
            }
            
        }

        private void FireWeapons(GameTime time, WeaponLoadoutState weaponLoadoutState, WeaponSlot weaponSlotFired)
        {
            
            if (weaponSlotFired.Equals(WeaponSlot.Main) && weaponLoadoutState.MainWeaponPauseTimer <= 0)
            {
                SpawnProjectile(weaponLoadoutState.Entity, _selectedMainWeapon.Projectile);
                IncreasePauseTimer(weaponLoadoutState, _selectedMainWeapon.DelayBetweenShots);
            }
            
        }

        private void UpdateWeaponsPauseTimer(GameTime time, WeaponLoadoutState weaponLoadoutState)
        {
            if (weaponLoadoutState.MainWeaponPauseTimer > 0f) weaponLoadoutState.MainWeaponPauseTimer -= (float)time.Elapsed.TotalSeconds;
        }

        private void IncreasePauseTimer(WeaponLoadoutState weaponLoadoutState, float delayBetweenShots)
        {
            weaponLoadoutState.MainWeaponPauseTimer = delayBetweenShots;
        }

        private void SpawnProjectile(Entity entity, Prefab projectile)
        {
            /*
             var entity = ShipState.Weapons[0].Weapon.Bullet.Instantiate()[0];
                        entity.Transform.Position = Entity.Transform.Position + new Vector3(0f, 0.5f, -0.2f);
                        Entity.Scene.Entities.Add(entity);
                        _timer = ShipState.Weapons[0].Weapon.BaseDelay;

             */

            var projectileEntity = projectile.Instantiate()[0];
            projectileEntity.Transform.Position = entity.Transform.Position + new Vector3(0f, 0.5f, -0.2f);
            entity.Scene.Entities.Add(projectileEntity);
        }

        private void SetCurrentWeapons(WeaponLoadoutState weaponLoadoutState)
        {
            if (!_mainWeaponSet && weaponLoadoutState.MainWeaponIds.Count() == 1)
            {
                Weapon weapon = WeaponsRegistry.Weapons.Where(w => w.Id.Equals(weaponLoadoutState.MainWeaponIds.First())).FirstOrDefault();
                if (weapon != null)
                {
                    _selectedMainWeapon = weapon;
                    _mainWeaponSet = true;
                }
            }
        }
    }
}
