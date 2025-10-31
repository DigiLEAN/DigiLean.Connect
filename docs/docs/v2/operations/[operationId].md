---
aside: false
outline: false
title: DigiLEAN Connect Docs
---

<script setup lang="ts">
  import { useRoute, useData } from 'vitepress'
  import { useTheme } from "vitepress-openapi/client"
  import OAParametersOverride from "../../../components/OAParametersOverride.vue"
  import OATryWithVariablesOverride from "../../../components/OATryWithVariablesOverride.vue"
  import spec from "../../../openApi/OpenApi3.0.v2.json" with { type: "json" }

  const route = useRoute()

  const { isDark } = useData()

  const operationId = route.data.params.operationId

  useTheme({
    requestBody: {
        // Set the default schema view.
        defaultView: 'schema', // schema or contentType
    }
  })


</script>

<!--override and hide stuff-->
<OAOperation :operationId="operationId" :hideBranding="true":spec>
    <template #parameters="parameters">
        <h2>Parameters</h2>
        <OAParametersOverride 
          :operation-id="operationId"
          :parameters="parameters.parameters"
        />
    </template>
    <template #security="security">
    </template>
    <template #code-samples="codeSamples">
    </template>
    <template #playground="slotProps">
        <OATryWithVariablesOverride 
          v-bind="{...slotProps, isDark}"
        />
    </template>
</OAOperation>
