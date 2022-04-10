var filter = document.forms[0].elements[0].value;
const output = document.querySelector('.output');
const output1 = document.createElement('div');
const ul = document.createElement('ul');
output.append(output1);
output.append(ul);
const url = 'https://localhost:7089/Status';
window.addEventListener('DOMContentLoaded', () => {
    output1.textContent = 'Lists of Companies';
    loadData();
})

function loadData() {
    fetch(url).then(rep => rep.json())
        .then((data) => {
            console.log(data);
            addtoPage(data);
        })
}

function addtoPage(arr) {
    arr.forEach((el) => {
        console.log(el);
        const li = document.createElement('li');
        li.textContent = el.name + ' : ' + el.status;
        if (el.status == 'Active') {
            li.classList.add('active');
        } else {
            li.classList.add('inactive');
        }
        ul.append(li);
        li.addEventListener('click', (e) => {
            li.classList.toggle('active');
            li.classList.toggle('inactive');
        })
    });
}