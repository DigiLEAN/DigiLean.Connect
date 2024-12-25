<script setup lang="ts">
    import "./digilean3dlogo/component"
    import { VPButton } from "vitepress/theme"
</script>
<style scoped>
    section {
        margin-top: 5rem;
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
    }
    section.boxes {
        gap: 1rem;
        margin-top: 1rem;
    }
    digilean-3d-spinner {
        width: 300px;
        height: 300px;
    }
    a {
        text-decoration: none;
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
    p.text {
        padding: 0.3rem 0;
        font-size: 3rem;
        line-height: 3.5rem;
        font-weight: 600;
    }
    div.actions {
        display: flex;
        gap: 1rem;
        .action {
            .VPButton.medium {
                border-radius: 5px;
            }
        }
    }
    article.box {
        padding: 1.2rem 2rem;
        flex: auto;
        display: block;
        border: 1px solid var(--vp-c-bg-soft);
        border-radius: 12px;
        background-color: var(--vp-c-bg-soft);
        transition: border-color .25s,background-color .25s;
        h2 {
            margin: 0;
            border-top: 0;
            font-size: 1rem;
            line-height: 1.5rem;
            padding-top: 0;
        }
        p {
            color: var(--vp-c-text-2);
            font-size: 0.9rem;
            margin: 0;
        }
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
            <section class="boxes">
                <article class="box">
                    <h2 class="title">Read/write DigiLEAN data</h2>
                    <p class="details">See docs and examples</p>
                </article>
                <article class="box">
                    <h2 class="title">Integrate with other systems</h2>
                    <p class="details">Automate data flows</p>
                </article>
            </section>
        </div>
        <div class="logo">
            <digilean-3d-spinner></digilean-3d-spinner>
        </div>
    </section>
    
</template>