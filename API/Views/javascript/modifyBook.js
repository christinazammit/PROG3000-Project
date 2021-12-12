document.getElementById("allbooks-button").addEventListener("click", (element) => {
    location.href = "index.html";
});

const id = localStorage.getItem("id");

document.getElementById("modifyButton").addEventListener("click", (element) => {
    var updatedTitle = document.getElementById("title");
    var updatedFirstName = document.getElementById("firstName");
    var updatedLastName = document.getElementById("lastName");
    var updatedGenre;

    if (document.getElementById("romance").checked) {
        updatedGenre = document.getElementById("romance");
    }
    else if (document.getElementById("mystery").checked) {
        updatedGenre = document.getElementById("mystery");
    }
    else if (document.getElementById("historical").checked) {
        updatedGenre = document.getElementById("historical");
    }
    else if (document.getElementById("nonfiction").checked) {
        updatedGenre = document.getElementById("nonfiction");
    }
    else if (document.getElementById("fantasy").checked) {
        updatedGenre = document.getElementById("fantasy");
    }
    else if (document.getElementById("horror").checked) {
        updatedGenre = document.getElementById("horror");
    }

    var updatedComment = document.getElementById("comment");

    fetch(`http://localhost:5000/api/update/${id}`, {
    method: "PUT",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify({
        title: updatedTitle.value,
        author: {
            firstName: updatedFirstName.value,
            lastName: updatedLastName.value,
        },
        genre: updatedGenre.value,
        comments: updatedComment.value,
    })
})

    .then(response => response.json())
    .then(data => console.log(data))
    location.href = "index.html";
})
