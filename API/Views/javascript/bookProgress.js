document.getElementById("allbooks-button").addEventListener("click", (element) => {
    location.href = "index.html";
});

const id = localStorage.getItem("id");

document.getElementById("updateButton").addEventListener("click", (element) => {
    var updatedPage = document.getElementById("currentPage");
    var updatedComplete;

    if (document.getElementById("complete").checked) {
        updatedComplete = true;
    }
    else {
        updatedComplete = false;
    }

    fetch(`http://localhost:5000/api/update/${id}/currentpage`, {
    method: "PUT",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify({
        currentpage: updatedPage.value,
        isbookcomplete: updatedComplete,
    })
})

    .then(response => response.json())
    .then(data => console.log(data))
    location.href = "index.html";
});