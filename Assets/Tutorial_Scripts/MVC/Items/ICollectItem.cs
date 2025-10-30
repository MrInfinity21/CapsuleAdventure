using UnityEngine;

public interface ICollectItem
{
    int PointValue { get; }
    void Collect(UnityEngine.GameObject collector);

}
    public interface ICollectInventory
    {
        void OnCollect(ICollectable collectable);
    }

   

    public interface ILifeCollectable
    {
        int HealthAmount { get; }
        void Collect(GameObject collector);
    }

    

