using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
namespace CApp.Client.ChatServices
{
    public class HubConnectionService
    {
        private readonly HubConnection _hubConnection;
        public bool IsConnected { get; set; }

        public HubConnectionService(NavigationManager navigationManager)
        {
            _hubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri("/chathub"))
            .Build();

            //Start the connection
            _hubConnection.StartAsync();
            GetConnectionState();
        }

        public HubConnection GetHubConnection() => _hubConnection;
        public bool GetConnectionState()
        {
            var hubConnection = GetHubConnection();
            IsConnected = hubConnection != null;
            return IsConnected;
        }
    }
}
