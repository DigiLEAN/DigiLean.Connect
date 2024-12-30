<script setup>
    import { onMounted  } from "vue"

    onMounted(() => {
        console.log("import module on mounted")
        // import("./digilean3dlogo/component")
    })
</script>
<style scoped>
    digilean-3d-spinner {
        width: 400px;
        height: 400px;
    }
</style>
<template>

    <digilean-3d-spinner></digilean-3d-spinner>

</template>