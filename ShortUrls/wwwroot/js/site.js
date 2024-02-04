function copyToClipboard() {
    const urlText = $("#short_url").text();

    navigator.clipboard.writeText(urlText);   
    $(".toast").toast('show');
    setTimeout(function () {
        $(".toast").toast('hide');
    }, 2000);
}