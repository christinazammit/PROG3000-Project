//
// Author: Christina Zammit
//

document.getElementById("allbooks-button").addEventListener("click", (element) => {
    location.href = "index.html";
});

const id = localStorage.getItem("id");

document.getElementById("currentPage").value = localStorage.getItem("page");
document.getElementById("comment").value = localStorage.getItem("comment");

console.log(localStorage.getItem("isComplete"));

if (localStorage.getItem("isComplete") == "true") {
    document.getElementById("complete").checked = true;
}
else {
    document.getElementById("complete").checked = false;
}

document.getElementById("updateButton").addEventListener("click", (element) => {
    var updatedPage = document.getElementById("currentPage");
    var updatedComment = document.getElementById("comment");
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
        comments: updatedComment.value,
        isbookcomplete: updatedComplete,
    })
})

    .then(response => response.json())
    .then(data => console.log(data))
    location.href = "index.html";
});