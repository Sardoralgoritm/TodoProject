function updateCompleted({ value }) {
  
    $.post('/Home/UpdateCompleted', { id: value }, function () {
        location.reload();
    });

}

todoDataForm.onsubmit = (e) => {
    e.preventDefault()
    const content = e.target[0].value
    $.post('/Home/Add', {content}, function () {
        location.reload();
    });
}

editDataForm.onsubmit = (e) => {
    e.preventDefault()
    const content = e.target[0].value
    const id = e.target[0].dataset.todoId
    console.log(content)
    console.log(id)
    $.post('/Home/Update', { id: id, content: content }, function () {
        location.reload();
    });
}

function showEditTodo(e) {
    editTodoButton.showModal()

    const text = e.parentElement.parentElement.querySelector(".card-title").innerText
    textareaTodo.value = text
    textareaTodo.dataset.todoId = e.value
    textareaTodo.focus()
}



function deleteTodo({ value }) {
    console.log(value)
    $.post('/Home/Delete', { id: value }, function () {
        location.reload();
    });
}

if (allTodo.children.length === 0) {
    allTodo.innerHTML = "No todos"
}
if (completedTodo.children.length === 0) {
    console.log(completedTodo.innerHTML)
    completedTodo.innerHTML = "No completed todos"
}



