function ShowLoadingScreen() {
    var body = document.body,
        html = document.documentElement;

    var height = Math.max(body.scrollHeight, body.offsetHeight,
        html.clientHeight, html.scrollHeight, html.offsetHeight);


    $("#divPleaseWait").css({ "display": "flex", "height": height + "px" });
}

function HideLoadingScreen() {
    $("#divPleaseWait").hide();
}