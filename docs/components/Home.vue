<script setup lang="ts">
    import "./digilean3dlogo/component"
    import { VPButton } from "vitepress/theme"
</script>
<style scoped>
    section {
        margin-top: 5rem;
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;
    }
    digilean-3d-spinner {
        width: 300px;
        height: 300px;
    }
    .main {
        flex: 60% 0 0;
    }
    .logo {
        flex: 40% 0 0;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    h1 {
        color: var(--vp-home-hero-name-color);
        font-size: 3rem;
        font-weight: 700;
        span.clip {
            background: var(--vp-home-hero-name-background);
            background-clip: text;
            -webkit-text-fill-color: var(--vp-home-hero-name-color);
        }
    }
    div.actions {
        display: flex;
    }
    
</style>
<template>
    <section>
        <div class="main">
            <h1 class="name">
                <span class="clip">DigiLEAN Connect</span>
            </h1>
            <p class="text">API Documentation</p>
            <div class="actions">
                <div class="action">
                    <VPButton
                        tag="a"
                        size="medium"
                        theme="brand"
                        text="API Docs"
                        href="/docs"
                    />
                </div>
                <div class="action">
                    <VPButton
                        tag="a"
                        size="medium"
                        theme="alt"
                        text="API Examples"
                        href="/examples"
                    />
                </div>
            </div>
        </div>
        <div class="logo">
            <digilean-3d-spinner></digilean-3d-spinner>
        </div>
    </section>

</template>