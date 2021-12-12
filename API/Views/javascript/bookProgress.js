document.getElementById("allbooks-button").addEventListener("click", (element) => {
    location.href = "index.html";
});

const id = localStorage.getItem("id");

const updateProgress = {
    currentpage: document.getElementById("currentPage").value
};

document.getElementById("updateButton").addEventListener("click", (element) => {
    fetch(`http://localhost:5000/api/update/${id}/currentpage`, {
    method: "PUT",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify(updateProgress)
})

    .then(response => response.json())
    .then(data => console.log(data))
    //location.href = "index.html";
    //console.log(updatedBook.title);
});