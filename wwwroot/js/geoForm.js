(function () {
    let url = "https://apis.datos.gob.ar/georef/api/provincias";
    getData(url, "provincia", "provincias", "nombre");
})();

function populateSelect(data, el, dataArg) {
    var node = document.getElementById(el);
    let fragment = document.createDocumentFragment();
    if (node.childElementCount > 1) {
        while (node.firstChild) {
            node.removeChild(node.firstChild);
        }
    }
    data.forEach(d => {
        let op = document.createElement('option');
        op.innerHTML = d[dataArg];
        fragment.append(op);
    })
    node.appendChild(fragment);
}


document.getElementById("provincia").addEventListener('change', (e) => {
    let prov = e.target.value.toLowerCase().trim();
    url = "https://apis.datos.gob.ar/georef/api/departamentos?provincia=" + prov + "&max=200";
    getData(url, "departamento", "departamentos", "nombre");
});

document.getElementById("departamento").addEventListener('change', (e) => {
    let prov = document.getElementById("provincia").value;
    let dept = e.target.value.toLowerCase().trim();
    let url = "https://apis.datos.gob.ar/georef/api/localidades?provincia=" + prov + "&departamento=" + dept + "&aplanar=true&campos=estandar&max=200&exacto=true";
    getData(url, "localidad", "localidades", "nombre");
});


function getData(url, node, type, dataArg) {
    let xhr = new XMLHttpRequest();
    xhr.open("get", url);
    xhr.send();
    xhr.addEventListener("readystatechange", (ev) => {
        if (xhr.readyState === 4) {
            let data = JSON.parse(xhr.responseText);
            populateSelect(data[type], node, dataArg);
        }
    });
}