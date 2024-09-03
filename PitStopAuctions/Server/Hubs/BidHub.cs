using Microsoft.AspNetCore.SignalR;

namespace PitStopAuctions.Server.Hubs;
public class BidHub : Hub
{
    public async Task SendBidUpdate(int leilaoId, Lance lance)
    {
        await Clients.All.SendAsync("ReceiveBidUpdate", leilaoId, lance);
    }
}
