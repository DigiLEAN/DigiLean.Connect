<script setup lang="ts">
    import { ref, onMounted, watch } from "vue"
    import { codeToHtml } from 'shiki'

    const props = defineProps({
        code: {
            type: String,
            required: true,
        },
        isDark: {
            type: Boolean,
            default: true,
        }
    })

    watch([() => props.code, () => props.isDark],
        () => {
            hl()
        }
    )
    const html = ref("")

    async function hl() {
        const h = await codeToHtml(props.code, {
            lang: 'http',
            theme: props.isDark ? "github-dark" : "github-light"
        })
        html.value = h
    }
    onMounted(() => {
        hl()
    })
</script>
<template>

<div class="vp-adaptive-theme language-http"
    v-html="html">
</div>

</template>