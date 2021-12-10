fetch('http://localhost:5000/api/display/completed', {
    method: "GET",
    headers: {
        "content-type": "application/json"
    }
})
    .then(response => response.json())
    .then(data => populateLibrary(data));

    function populateLibrary(Books) {
        Books.forEach(book => addBook(book));
    }

    function addBook(book) {
        
        var table = document.getElementById("myCompletedTable");

        var rowNode = document.createElement("tr");

        var nodeTitle = document.createElement("td");
        nodeTitle.innerHTML = book.title;

        var nodeAuthor = document.createElement("td");
        nodeAuthor.innerHTML = `${book.author.firstName} ${book.author.lastName}`;

        var nodeGenre = document.createElement("td");
        nodeGenre.innerHTML = book.genre;

        var nodeProgress = document.createElement("td");
        if (book.isBookComplete == true) {
            nodeProgress.innerHTML = "Completed";
        }
        else {
            nodeProgress.innerHTML = `${book.currentPage} out of ${book.totalPages}`; 
        }
        
        var nodeComments = document.createElement("td");
        if (book.comments == undefined) {
            nodeComments.innerHTML = "";
        }
        else {
            nodeComments.innerHTML = book.comments;
        }

        var nodeUpdate = document.createElement("td");
        
        var modifyBtn = document.createElement("button");
        modifyBtn.innerHTML = "Modify";
        modifyBtn.id = "modifybtn";
        nodeUpdate.appendChild(modifyBtn);
        modifyBtn.onclick = function () {
            localStorage.setItem("id", book.id);
            location.href = "ModifyBook.html";
        }

        var progressBtn = document.createElement("button");
        progressBtn.innerHTML = "Update Progress";
        progressBtn.id = "progressbtn";
        nodeUpdate.appendChild(progressBtn);
        progressBtn.onclick = function () {
            localStorage.setItem("id", book.id);
            location.href = "BookProgress.html";
        }
        
        rowNode.appendChild(nodeTitle);
        rowNode.appendChild(nodeAuthor);
        rowNode.appendChild(nodeGenre);
        rowNode.appendChild(nodeProgress);
        rowNode.appendChild(nodeComments);
        rowNode.appendChild(nodeUpdate);

        table.appendChild(rowNode);

        console.log(table);
    }

document.getElementById("allbooks-button").addEventListener("click", (element) => {
    location.href = "index.html";
});