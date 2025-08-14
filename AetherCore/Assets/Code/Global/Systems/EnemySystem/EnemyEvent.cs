using UnityEngine;

public class EnemyEvent
{
    public string EventType { get; private set; }  // Ej: "PlayerDetected", "DamageTaken"
    public object EventData { get; private set; }  // Datos extra que puedan ser útiles

    public EnemyEvent(string eventType, object eventData = null)
    {
        EventType = eventType;
        EventData = eventData;
    }
}

