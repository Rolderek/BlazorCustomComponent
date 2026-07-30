//egy sima JS ami importál mindent ami kell hogy Blazor component-ek fussanak
//sajnos egyszerre csak egy blazorsite-ot fogunk tudni futtatni

var scriptUrl = document.currentScript.src;
var url = new URL(scriptUrl);
var customElementBaseUrl = url.origin;
//bármi amiben content van azt innen kérje le, ne az eredeti eljárással
//a "customElementBaseUrl"-nél keresse a cuccokat
const importMap = {
    imports: {
        [`${window.location.origin}/_content/`]: `${customElementBaseUrl}/_content/`,
    }
}

const importMapJson = JSON.stringify(importMap);
const scriptimportmap = document.createElement('script');
scriptimportmap.type = 'importmap';
scriptimportmap.textContent = importMapJson;
document.head.appendChild(scriptimportmap);
//scriptben végezzük el a létrehozást
var blazorscript = document.createElement('script'); //legyen script
blazorscript.src = `${customElementBaseUrl}/_framework/blazor.webassembly.js`; //ez a source
blazorscript.type = 'text/javascript'; //típus
blazorscript.setAttribute('AutoStart', 'false'); //azért false, mert indítási intrukciókat akarunk megadni
blazorscript.onload = function () { //mikor betöltődött
    Blazor.start({
        loadBootResource: function (type, name, defaultUri, integrity) {
            if (type == 'dotnetjs') {
                return `${customElementBaseUrl}/_framework/${name}`;
            } else {
                return fetch(`${customElementBaseUrl}/_framework/${name}`, {
                    cache: 'no-cache',
                    integrity: integrity
                });
            }
        }
    });
};

document.head.appendChild(blazorscript);