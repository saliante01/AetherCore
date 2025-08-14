using System;
using System.Collections.Generic;

public static class EventManager
{
    private static List<IEnemyEventListener> listeners = new List<IEnemyEventListener>();

    // Registrar un listener
    public static void RegisterListener(IEnemyEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    // Eliminar un listener
    public static void UnregisterListener(IEnemyEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }

    // Disparar evento a todos los listeners
    public static void TriggerEvent(EnemyEvent enemyEvent)
    {
        foreach (var listener in listeners)
        {
            listener.OnEnemyEvent(enemyEvent);
        }
    }
}
