<script setup lang="ts">
    import "./digilean3dlogo/component"
</script>
<style scoped>
    section {
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
                    <a class="VPButton medium brand" href="/docs">Api Docs</a>
                </div>
                <div class="action">
                    <a  class="VPButton medium alt" href="/examples">API Examples</a>
                </div>
            </div>
        </div>
        <div class="logo">
            <digilean-3d-spinner></digilean-3d-spinner>
        </div>
    </section>

</template>