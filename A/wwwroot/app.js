const result = document.getElementById('results');
const url = 'https://localhost:7089/Status';
const urlSync = 'https://localhost:7089/Synchronize';

window.addEventListener('DOMContentLoaded', () => {
    loadData();
})

function loadData() {
    fetch(url).then(rep => rep.json())
        .then((data) => {
            var list = [];
            data.forEach(x => {
                list.push(x.name+':'+x.status);
            });
            console.log(data);
            renderList(list, result);
            document.getElementById('search').addEventListener('input', e => renderList(filter(e.target.value, list), result));

        })
}
function filter(val, list) {
   // console.time('test')
    return list.filter(i => (~i.indexOf(val)))
};
function renderList(_list = [], el = document.body) {
    el.innerHTML = '';
    _list.forEach(i => {
        let new_el = document.createElement('li')
        new_el.innerHTML = i
        el.appendChild(new_el)
    })
}
function sync() {
    fetch(urlSync);
    location.reload();
}

