function updateCompleted({ value }) {
  
    $.post('/Home/UpdateCompleted', { id: value }, function () {
        location.reload();
    });

}

todoDataForm.onsubmit = (e) => {
    e.preventDefault()
    const data = e.target[0].value
    console.log(data);
    console.log(typeof data);
    $.post('/Home/Add', {vm: data}, function () {
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



