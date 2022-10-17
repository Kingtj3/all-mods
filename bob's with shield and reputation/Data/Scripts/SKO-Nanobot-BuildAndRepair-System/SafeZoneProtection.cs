using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using SpaceEngineers.Game.Entities.Blocks.SafeZone;
using SpaceEngineers.Game.ModAPI;
using SpaceEquipmentLtd.Utils;
using VRage.Game.ModAPI;
using VRageMath;
using VRageRender.Messages;

namespace BattleStarNanoBuildAndRepairSystem
{
    public static class SafeZoneProtection
    {
        public static T CastProhibit<T>(T ptr, object val) => (T)val;

        public static bool IsProtected(IMySlimBlock targetBlock, IMyCubeBlock attackerBlock)
        {
            try
            {
                if (targetBlock != null && attackerBlock != null)
                {
                    var sphere = new BoundingSphereD(attackerBlock.GetPosition(), 500);
                    var list = MyAPIGateway.Entities.GetEntitiesInSphere(ref sphere);
                    var safeZones = list.OfType<MySafeZone>().ToList();

                    if (safeZones.Any())
                    {
                        BoundingBoxD targetBox;
                        targetBlock.GetWorldBoundingBox(out targetBox);

                        BoundingBoxD attackerBox;
                        attackerBlock.SlimBlock.GetWorldBoundingBox(out attackerBox);

                        foreach (var safeZone in safeZones)
                        {
                            // Create a new sphere for the safe zone.
                            BoundingSphereD checkSphere = new BoundingSphereD(safeZone.PositionComp.GetPosition(), safeZone.Radius);

                            // Get intersections checks..
                            var targetIntersects = checkSphere.Intersects(targetBox);
                            if (targetIntersects)
                            {
                                // If it is a safe-zone block.
                                if (safeZone.SafeZoneBlockId > 0)
                                {
                                    var safeZoneBlock = MyEntities.GetEntityByName(safeZone.SafeZoneBlockId.ToString()) as IMySafeZoneBlock;
                                    if (safeZoneBlock != null && safeZoneBlock.Enabled && safeZoneBlock.IsSafeZoneEnabled())
                                    {
                                        var isAllowed = safeZone.IsActionAllowed(targetBox, CastProhibit(MySessionComponentSafeZones.AllowedActions, 16));
                                        if (isAllowed)
                                        {
                                            var safeZoneBlockOwner = UtilsPlayer.GetOwner(safeZoneBlock.CubeGrid);
                                            var targetGridOwner = UtilsPlayer.GetOwner(targetBlock.CubeGrid);
                                            var attackerGridOwner = UtilsPlayer.GetOwner(attackerBlock.CubeGrid);

                                            if (safeZoneBlockOwner == attackerGridOwner || targetGridOwner == attackerGridOwner)
                                            {
                                                return false;
                                            }

                                            // Check relation between owners.
                                            var relation = attackerBlock.GetUserRelationToOwner(targetGridOwner);
                                            if (relation == VRage.Game.MyRelationsBetweenPlayerAndBlock.Owner ||
                                                relation == VRage.Game.MyRelationsBetweenPlayerAndBlock.FactionShare)
                                            {
                                                return false;
                                            }
                                        }

                                        return true;
                                    }
                                }

                                return true;
                            }
                        }
                    }
                }
            }
            catch { }

            return false;
        }
    }
}
