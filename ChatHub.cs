using Microsoft.AspNetCore.SignalR;

namespace ChatHub1;

public class ChatHub : Hub {

    public const string HubUrl = "/chat";

    public override Task OnConnectedAsync() {
        Console.WriteLine($"{Context.ConnectionId} is connected.");
        return base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? e) {
        Console.WriteLine($"{e!.Message} {Context.ConnectionId}");
        await base.OnDisconnectedAsync(e);
    }

    public async Task Broadcast(string user, string message) {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

}