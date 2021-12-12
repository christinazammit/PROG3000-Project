//
// Author: Christina Zammit
//

// creates event listener to the all book button that navigates users to the all books page
document.getElementById("allbooks-button").addEventListener("click", (element) => {
    location.href = "index.html";
});

// gets id from the local storage
const id = localStorage.getItem("id");

// sets the current page to the value from local storage
document.getElementById("currentPage").value = localStorage.getItem("page");

// sets the comment to the value from local storage
document.getElementById("comment").value = localStorage.getItem("comment");

// sets the completion status to the value from local storage
if (localStorage.getItem("isComplete") == "true") {
    document.getElementById("complete").checked = true;
}
else {
    document.getElementById("complete").checked = false;
}

// creates event listener to the update button that updates the books progress
document.getElementById("updateButton").addEventListener("click", (element) => {
    
    // gets the user input for the current page
    var updatedPage = document.getElementById("currentPage");

    // gets the user input for the comments
    var updatedComment = document.getElementById("comment");
    var updatedComplete;

    // sets the value of updatedComplete to true if complete is checked and false if unchecked
    if (document.getElementById("complete").checked) {
        updatedComplete = true;
    }
    else {
        updatedComplete = false;
    }

    // retreives the url for updating the book progress given the book id
    fetch(`http://localhost:5000/api/update/${id}/currentpage`, {
    method: "PUT",
    headers: {
        "Content-Type": "application/json"
    },
    
    // converts updatedPage, updatedComment, and updatedComplete to JSON to be stored in database
    body: JSON.stringify({
        currentpage: updatedPage.value,
        comments: updatedComment.value,
        isbookcomplete: updatedComplete,
    })
})

    // json response
    .then(response => response.json())
    .then(data => console.log(data))

    // navigates to the index page to view all books in library
    location.href = "index.html";
});