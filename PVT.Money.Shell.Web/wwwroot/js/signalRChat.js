$(document).ready(function () {
    let hubUrl = 'http://localhost:50462/SomeChat';
    let httpConnection = new signalR.HttpConnection(hubUrl);
    let hubConnection = new signalR.HubConnection(httpConnection);
    hubConnection.on("Send", function (message) {
        window.alert(message);
    });
    hubConnection.start();
    SendMessage(hubConnection);
})


function SendMessage(hubConnection)
{
    setTimeout(
        function () {
            hubConnection.invoke("Receive", "Hello after setTimeout");
        }, 10000);

   
}