const html = String.raw

export class DigiLeanLogo extends HTMLElement {
    static observedAttributes = ["spinning"]

    attributeChangedCallback(name, oldValue, newValue) {
        if (name == "spinning") {
            this.toggleSpinning()
        }
    }

    get spinning() {
        const spinning = this.getAttribute("spinning")
        return typeof spinning === "string"
    }

    toggleSpinning() {
        if (!this.shadowRoot)
            return
        let figure = this.shadowRoot.querySelector("figure")
        if (!figure)
            return
        
        if (this.spinning)
            figure.classList.add("spinning")
        else
            figure.classList.remove("spinning")
    }

    connectedCallback() {
        this.attachShadow({ mode: "open" })
        this.shadowRoot.innerHTML = this.render()
        this.toggleSpinning()
    }

    render() {
        return html`
            <style>
                :host {
                    display: block;
                    --logo-top-left-color: #acd3ef; /* --digilean-blue-sky-light */
                    --logo-main-color: #1c93d3; /* --digilean-blue */
                    --logo-spinner-speed: 2s;
                }
                figure {
                    height: var(--digilean-image-height, 3rem);
                    width: var(--digilean-image-width, 3rem);
                    display: block;
                    margin-block-start: 0;
                    margin-block-end: 0;
                    margin-inline-start: 0;
                    margin-inline-end: 0;
                }
                svg {
                    height: var(--digilean-image-height, 3rem);
                    width: var(--digilean-image-width, 3rem);
                }
                figure.spinning {
                    animation: spin var(--logo-spinner-speed) linear infinite;
                    transform-origin: center;
                }
                @keyframes spin {
                    from { transform: rotate(0deg) }
                    to { transform: rotate(360deg) }
                }
            </style>
            <figure class="digilean-logo">
                <svg xmlns="http://www.w3.org/2000/svg" id="digilean-logo-def" viewBox="0 0 582 582">
                    <g id="logo" transform="translate(0,582) scale(0.1,-0.1)">
                        <path id="top-right" fill="var(--logo-main-color)"
                            d="m 5195,2678 -460,-230 -432,216 c -238,119 -435,216 -437,216 -2,0 -6,-33 -9,-72 -26,-314 -237,-618 -532,-763 l -89,-44 -232,-463 -232,-463 229,-457 c 208,-416 231,-458 253,-458 50,0 296,51 417,85 1040,302 1810,1184 1969,2255 23,153 38,410 24,409 -5,0 -216,-104 -469,-231 z" />
                        <path id="bottom-right" fill="var(--logo-main-color)"
                            d="m 3154,5212 234,-467 -214,-425 c -117,-234 -213,-430 -213,-435 -1,-6 37,-16 82,-23 308,-45 580,-244 721,-529 l 33,-66 459,-233 c 252,-129 468,-234 478,-234 15,0 899,440 914,455 13,13 -57,341 -105,490 -313,981 -1124,1699 -2133,1890 -110,21 -336,45 -423,45 h -67 z" />
                        <path id="bottom-left" fill="var(--logo-main-color)"
                            d="M 605,2813 C 358,2689 153,2586 151,2584 c -2,-2 2,-40 8,-86 63,-438 261,-909 533,-1265 410,-538 1023,-921 1665,-1043 202,-38 533,-65 533,-44 0,3 -105,212 -232,464 l -233,459 217,434 c 119,239 214,438 211,441 -4,3 -25,6 -48,6 -66,0 -224,44 -318,89 -202,97 -358,257 -472,486 -19,38 -35,47 -490,276 l -470,237 z" />
                        <path id="top-left" fill="var(--logo-top-left-color)"
                            d="M 2390,5635 C 1966,5554 1575,5381 1231,5122 1090,5016 858,4792 748,4656 395,4218 191,3712 140,3145 c -12,-130 -13,-215 -3,-215 4,0 211,102 460,228 l 452,227 436,-217 c 239,-120 439,-218 444,-218 4,0 11,30 14,68 29,326 266,646 575,776 l 56,24 235,463 235,464 -230,455 -230,455 -35,2 c -19,1 -90,-9 -159,-22 z" />                                                
                    </g>
                </svg>
                <figcaption></figcaption>
            </figure>
        `
    }
}

customElements.define('digilean-logo', DigiLeanLogo)