document.getElementById("search").addEventListener("change", () => {

    links = document.querySelectorAll(".btn-search");
    console.log(links);
    for (let i = 0; i < links.length; i++) {
        if (links[i].href != "#") {
            links[i].href = '//' + location.host + location.pathname + "?page=" + 1 + "&search=" + document.getElementById("search").value;
        }
    }
})