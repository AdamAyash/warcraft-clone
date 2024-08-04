namespace CoreKitEngine.Engine.ColisionDetecionSystem.CollisionDetectors
{
    using CoreKitEngine.Engine.ColisionDetecionSystem.CollisionResolver;
    using CoreKitEngine.Engine.ColliderSystem.Colliders;
    using CoreKitEngine.Engine.GameObjects;

    public class AABBCollisionDetecor<PassiveObject, ActiveObject> : ICollisionDetector
        where PassiveObject : GameObject
        where ActiveObject :  GameObject
    {
        private List<PassiveObject> m_oPassiveObjectsList;
        private List<ActiveObject> m_oActiveObjectsList;

        private ICollisionResolver m_oCollisionResolver;

        public AABBCollisionDetecor(List<PassiveObject> oPassiveObjectsList, 
            List<ActiveObject> oActiveObjectsList, ICollisionResolver oCollisionResolver)
        {
            m_oPassiveObjectsList = oPassiveObjectsList;
            m_oActiveObjectsList = oActiveObjectsList;
            m_oCollisionResolver = oCollisionResolver;
        }

        private bool DetectCollision(PassiveObject oPassiveObject, ActiveObject oActiveObject)
        {
            foreach (BoxCollider oPassiveObjectBoxColider in oPassiveObject.BoxColidersList.Value)
            {
                foreach (BoxCollider oActiveObjectBoxColider in oActiveObject.BoxColidersList.Value)
                {
                    if(oPassiveObjectBoxColider.IsCollidingWith(oActiveObjectBoxColider))
                        return true;
                }
            }

            return false;
        }

        public void DetectCollisions()
        {
            foreach (PassiveObject oPassiveObject in m_oPassiveObjectsList)
            {
                foreach (ActiveObject oActiveObject in m_oActiveObjectsList)
                {
                    if(DetectCollision(oPassiveObject, oActiveObject))
                        m_oCollisionResolver.Resolve();
                }
            }
        }
    }
}
