---
aside: false
outline: false
title: DigiLEAN Connect Docs
---

<script setup lang="ts">
  import { useRoute, useData } from 'vitepress'
  import OAParametersOverride from "../../components/OAParametersOverride.vue"
  import OATryWithVariablesOverride from "../../components/OATryWithVariablesOverride.vue"

  const route = useRoute()

  const { isDark } = useData()

  const operationId = route.data.params.operationId

</script>

<!--override and hide stuff-->
<OAOperation :operationId="operationId" :isDark="isDark" :hideDefaultFooter="true">
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
    <template #try-it="tryIt">
    <OATryWithVariablesOverride 
      :operation-id="tryIt.operationId"
      :path="tryIt.path"
      :method="tryIt.method"
      :base-url="tryIt.baseUrl"
      :parameters="tryIt.parameters"
      :schema="tryIt.schema"
      :security-schemes="tryIt.securitySchemes"
      :is-dark="isDark"
    />
  </template>
</OAOperation>
