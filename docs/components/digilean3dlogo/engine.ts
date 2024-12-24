import * as B from "@babylonjs/core"
import "@babylonjs/loaders/glTF"


// https://www.youtube.com/watch?v=b7-VKQeQiV4 

export class dSpinner {
    ownerEl: HTMLElement
    canvas: HTMLCanvasElement
    engine: B.Engine
    scene: B.Scene | undefined

    constructor(ownerEl: HTMLElement, canv: HTMLCanvasElement) {
        this.ownerEl = ownerEl
        this.canvas = canv
        this.engine = new B.Engine(this.canvas)
    }

    async start(width: number, height: number) {
        //await this.engine.initAsync()
        
        this.engine.setSize(width, height)
        this.scene = new B.Scene(this.engine)
        
        //this.scene.clearColor = new B.Color4(0.090196, 0.090196, 0.090196, 1)
        //this.scene.clearColor = B.Color4.FromHexString("#1b1b1f")
        this.scene.clearColor = new B.Color4(0,0,0,0.000001);

        const myMaterial = new B.StandardMaterial("std", this.scene)
        myMaterial.diffuseColor = new B.Color3(1, 1, 1);
        myMaterial.specularColor = new B.Color3(1, 0, 0.87);
        myMaterial.ambientColor = new B.Color3(1, 0, 1);
        const result = await B.SceneLoader.ImportMeshAsync(null, "/3d/", "digilean3d.glb", this.scene, (e) => {
            console.log(e)
        })
        
        const meshRoot = result.meshes[0] as B.Mesh
        const meshes = meshRoot.getChildMeshes()

        const scale = 30
        meshes.forEach(m => {
            m.isPickable = false
        })
        //meshRoot.rotation.x = 1
        // meshRoot.position.y = 0
        //meshRoot.scaling = new B.Vector3(scale, scale, scale)
        const material = new B.PBRMetallicRoughnessMaterial("pbr", this.scene)
        // material.baseColor = new B.Color3(0, 0.5, 0.8);
        material.baseColor = B.Color3.FromHexString("#1c93d3")
        material.metallic = 0.99
        material.roughness = 0.5
        //meshRoot.material = pbr
        const materialTopLeft = new B.PBRMetallicRoughnessMaterial("pbr", this.scene)
        materialTopLeft.baseColor = B.Color3.FromHexString("#acd3ef")
        // materialTopLeft.baseColor = new B.Color3(0, 0.5, 0.9);
        materialTopLeft.metallic = 0.9
        materialTopLeft.roughness = 0.3

        meshes[0].material = material
        meshes[1].material = materialTopLeft
        meshes[1].metadata = "top left"
        meshes[2].material = material
        meshes[3].material = material

        const mergedMesh = B.Mesh.MergeMeshes(meshes as B.Mesh[], true, true, undefined, false, true)
        if (!mergedMesh)
            return
        mergedMesh.scaling = new B.Vector3(scale, scale, scale)
        mergedMesh.position.x = 1
        // mergedMesh.rotateAround(new B.Vector3(0,0,0), new B.Vector3(1,0,0), Math.PI/2)
        // const gl = new B.GlowLayer("glow", this.scene);
        // gl.addIncludedOnlyMesh(meshRoot);

        const cameraAngle = new B.Vector3(1, 0, 0) //B.Vector3.Zero()
        const camera = new B.ArcRotateCamera("Camera", 1, 5, 4, cameraAngle, this.scene)
        camera.attachControl(this.canvas, false)

        const light = new B.HemisphericLight("light1", new B.Vector3(1, 5, 8), this.scene)
        light.intensity = 1

        const light2 = new B.HemisphericLight("light2", new B.Vector3(-5, -10, 1), this.scene)
        light2.intensity = 1
        const light3 = new B.HemisphericLight("light2", new B.Vector3(0.5, 1, 0.4), this.scene)
        light3.intensity = 1
        // const light4 = new B.HemisphericLight("light2", new B.Vector3(0.1, 0, 0), this.scene)
        // light4.intensity = 1

        this.createAnimation(mergedMesh)
        this.engine.runRenderLoop(() => {
            if (this.scene) {
                this.scene.render()
           }
        })
        return true
    }
    stop() {
        this.engine.stopRenderLoop()
    }
    createAnimation(mesh: B.Nullable<B.Mesh>) {
        if (!mesh)
            return
        
        const fps = 60

        // spinner
        const keyFramesSpin = [
            { frame: 0, value: 0 },
            { frame: 360, value: -2*Math.PI}
        ]
        const rotateAnim = new B.Animation("rotateAnim", "rotation.y", fps, B.Animation.ANIMATIONTYPE_FLOAT, B.Animation.ANIMATIONLOOPMODE_CYCLE)
        rotateAnim.setKeys(keyFramesSpin)
        mesh.animations.push(rotateAnim)

        // turn to right side
        const keyFramesTurn = [
            { frame: 0, value: 0 },
            { frame: 1, value: Math.PI }
        ]
        const rotationTurn = new B.Animation("turnAnim", "rotation.x", fps, B.Animation.ANIMATIONTYPE_FLOAT, B.Animation.ANIMATIONLOOPMODE_CONSTANT)
        rotationTurn.setKeys(keyFramesTurn)
        mesh.animations.push(rotationTurn)

        // tip
        const keyFramesTip = [
            { frame: 0, value: 0 },
            { frame: 20, value: -0.3 },
        ]
        const rotationTip = new B.Animation("tipAnim", "rotation.z", fps, B.Animation.ANIMATIONTYPE_FLOAT, B.Animation.ANIMATIONLOOPMODE_CONSTANT)
        rotationTip.setKeys(keyFramesTip)

        if (this.scene) {
            // this.scene.beginAnimation(mesh, 0, 180, true)
            this.scene.beginDirectAnimation(mesh, [rotateAnim, rotationTurn, rotationTip], 0, 360, true)
        }
            
    }
    resize(width: number, height: number) {
        this.canvas.height = width
        this.canvas.width = height
        this.engine.resize()
    }
}