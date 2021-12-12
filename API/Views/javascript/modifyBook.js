//
// Author: Christina Zammit
//

// creates event listener to the all book button that navigates users to the all books page
document.getElementById("allbooks-button").addEventListener("click", (element) => {
    location.href = "index.html";
});

// gets id from the local storage
const id = localStorage.getItem("id");

// sets the title to the value from local storage
document.getElementById("title").value = localStorage.getItem("title");

// sets the first name to the value from local storage
document.getElementById("firstName").value = localStorage.getItem("firstName");

// sets the last name to the value from local storage
document.getElementById("lastName").value = localStorage.getItem("lastName");

// sets the genre to the value from local storage
if (localStorage.getItem("genre") == "Romance") {
    document.getElementById("romance").checked = true;
}
else if (localStorage.getItem("genre") == "Mystery") {
    document.getElementById("mystery").checked = true;
}
else if (localStorage.getItem("genre") == "Historical") {
    document.getElementById("historical").checked = true;
}
else if (localStorage.getItem("genre") == "NonFiction") {
    document.getElementById("nonfiction").checked = true;
}
else if (localStorage.getItem("genre") == "Fantasy") {
    document.getElementById("fantasy").checked = true;
}
else if (localStorage.getItem("genre") == "Horror") {
    document.getElementById("horror").checked = true;
}

// sets the comments to the value from local storage
document.getElementById("comment").value = localStorage.getItem("comment");

// creates event listener to the modify button that updates the books information
document.getElementById("modifyButton").addEventListener("click", (element) => {
   
    // gets the user input for the title
    var updatedTitle = document.getElementById("title");

    // gets the user input for the first name
    var updatedFirstName = document.getElementById("firstName");

    // gets the user input for the last name
    var updatedLastName = document.getElementById("lastName");
    var updatedGenre;

    // gets the user input for the genre
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

    // gets the user input for the comment
    var updatedComment = document.getElementById("comment");

    // retreives the url for updating the books information given the book id
    fetch(`http://localhost:5000/api/update/${id}`, {
    method: "PUT",
    headers: {
        "Content-Type": "application/json"
    },

    // converts updatedTitle, updatedFirstName, updatedLastName, updatedGenre, and updatedComment to JSON to be stored in database
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
    // json response
    .then(response => response.json())
    .then(data => console.log(data))

    // navigates to the index page to view all books in library
    location.href = "index.html";
})
