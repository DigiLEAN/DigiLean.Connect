<script setup lang="ts">
    import { ref } from "vue"
    import * as msal from "../services/msalConnect"

    const errorMsg = ref("")

    const btnAzureEnabled = ref(true)
    const btnSharePointEnabled = ref(true)
    const btnSharePointSiteEnabled = ref(true)

    async function connectAzureAd() {
        btnAzureEnabled.value = false
        try {
            const res = await msal.signInAzureAdApp()
            errorMsg.value = "Successfully connected to DigiLEAN Connect Azure AD"
        }
        catch(err) {
            errorMsg.value = "error occured"
        }
    }
    async function connectSharePoint() {
        btnSharePointEnabled.value = false
        try {
            const res = await msal.signInSharePointApp()
            errorMsg.value = "Successfully connected to DigiLEAN Connect Sharepoint"
        }
        catch(err) {
            errorMsg.value = "error occured"
        }
    }
    async function connectSharepointSite() {
        btnSharePointSiteEnabled.value = false
        try {
            const res = await msal.signInSharePointSiteApp()
            errorMsg.value = "Successfully connected to DigiLEAN Connect Sharepoint"
        }
        catch(err) {
            errorMsg.value = "error occured"
        }
    }
</script>
<style>
    .connect-button {
        cursor: pointer;
        background: var(--digilean-blue-sharp);
        color: var(--digilean-white);
        padding: 0.375rem 0.75rem;
        font-size: 1rem;
        line-height: 1.5;
        border-radius: 0.25rem;
        border: 1px solid transparent;
        transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        margin: 0.5rem 4rem;
    }
    #btn-connect:disabled,
    button:disabled,
    button[disabled]{
        cursor: unset;
        border: 1px solid #999999;
        background-color: #cccccc;
        color: #666666;
    }
    section.entra-buttons {
        margin: auto;
        width: 50%;
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
</style>
<template>

<article>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <section class="entra-buttons">
        <button id="btn-connect-azure" class="connect-button" 
            :disabled="!btnAzureEnabled" @click="connectAzureAd">
            Connect Azure AD
        </button>
        <button id="btn-connect-sharepoint" class="connect-button" 
            :disabled="!btnSharePointEnabled" @click="connectSharePoint">
            Connect Sharepoint
        </button>
        <button id="btn-connect-sharepoint-site" class="connect-button" 
            :disabled="!btnSharePointSiteEnabled" @click="connectSharepointSite">
            Connect Sharepoint Selected Site
        </button>
        <p>&nbsp;</p>
        <div id="messageBox">
        {{ errorMsg }}
    </div>
    </section>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</article>


</template>