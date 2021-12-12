//
// Author: Christina Zammit
//

// fetches the url that displays all completed books
fetch('http://localhost:5000/api/display/completed', {
    method: "GET",
    headers: {
        "content-type": "application/json"
    }
})
    // gets json response
    .then(response => response.json())

    // calls populateLibrary function
    .then(data => populateLibrary(data));

    // function that calls the addBook function for each book in the database
    function populateLibrary(Books) {
        Books.forEach(book => addBook(book));
    }

    // creates a row for each book
    function addBook(book) {
        
        // retreives the table from the HTML file
        var table = document.getElementById("myCompletedTable");

        // creates a new row for the book
        var rowNode = document.createElement("tr");

        // creates a column for the title
        var nodeTitle = document.createElement("td");
        nodeTitle.innerHTML = book.title;

        // creates a column for the author
        var nodeAuthor = document.createElement("td");
        nodeAuthor.innerHTML = `${book.author.firstName} ${book.author.lastName}`;

        // creates a column for the genre
        var nodeGenre = document.createElement("td");
        nodeGenre.innerHTML = book.genre;

        // creates a column for the book progress
        var nodeProgress = document.createElement("td");
        if (book.isBookComplete == true) {
            nodeProgress.innerHTML = "Completed";
        }
        else {
            nodeProgress.innerHTML = `${book.currentPage} out of ${book.totalPages}`; 
        }
        
        // creates a column for the book comments
        var nodeComments = document.createElement("td");
        if (book.comments == undefined) {
            nodeComments.innerHTML = "";
        }
        else {
            nodeComments.innerHTML = book.comments;
        }

        // creates the updates column
        var nodeUpdate = document.createElement("td");
        
        // creates the modify button
        var modifyBtn = document.createElement("button");
        modifyBtn.innerHTML = "Modify";
        modifyBtn.id = "modifybtn";

        // adds the modify button to the update column
        nodeUpdate.appendChild(modifyBtn);

        // on click, saves books title, author, genre, and comments to local storage
        modifyBtn.onclick = function () {
            localStorage.setItem("id", book.id);
            localStorage.setItem("title", book.title);
            localStorage.setItem("firstName", book.author.firstName);
            localStorage.setItem("lastName", book.author.lastName);
            localStorage.setItem("genre", book.genre);
            localStorage.setItem("comment", book.comments);
            location.href = "ModifyBook.html";
        }

         // creates the progress button
        var progressBtn = document.createElement("button");
        progressBtn.innerHTML = "Update Progress";
        progressBtn.id = "progressbtn";

        // adds the progress button to the update column
        nodeUpdate.appendChild(progressBtn);

        // on click, saves books title, author, genre, and comments to local storage
        progressBtn.onclick = function () {
            localStorage.setItem("id", book.id);
            localStorage.setItem("comment", book.comments);
            localStorage.setItem("page", book.currentPage);
            localStorage.setItem("isComplete", book.isBookComplete);
            location.href = "BookProgress.html";
        }
        
         //appends all columns to the row
        rowNode.appendChild(nodeTitle);
        rowNode.appendChild(nodeAuthor);
        rowNode.appendChild(nodeGenre);
        rowNode.appendChild(nodeProgress);
        rowNode.appendChild(nodeComments);
        rowNode.appendChild(nodeUpdate);

        table.appendChild(rowNode);

        console.log(table);
    }

// creates event listener to the all book button that navigates users to the all books page
document.getElementById("allbooks-button").addEventListener("click", (element) => {
    location.href = "index.html";
});