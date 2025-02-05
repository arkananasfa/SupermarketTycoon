using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    public List<Client> NextClients = new();
    public ObservableValue<Client> CurrentClient = new ObservableValue<Client>();

    public void OnClientCome(Client client)
    {
        if (CurrentClient.Value == null)
            CurrentClient.Value = client;
        else 
            NextClients.Add(client);
    }

    public void CompleteTransaction()
    {
        if (CurrentClient.Value != null)
        {
            CurrentClient.Value.OnTransactionComplete();
            if (NextClients.Count > 0)
            {
                CurrentClient.Value = NextClients.First();
                NextClients.Remove(CurrentClient.Value);
            }
            else   
            {
                CurrentClient.Value = null;
            }
        }
    }
}