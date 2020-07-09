import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
declare var ol: any;
@Component({
    selector: 'app-map-component',
    templateUrl: './map-component.component.html',
    styleUrls: ['./map-component.component.less']
})
export class MapComponentComponent implements OnInit {

    @Input() selectEnabled = false;


    private _coordinatesList: Coordinates[] = [];
    private initialized: boolean;


    get coordinatesList(): Coordinates[] {
        return this._coordinatesList;
    }

    @Input() set coordinatesList(value: Coordinates[]) {
        if (value && value.length) {
            this._coordinatesList = value;
            this.reDrawPoints();
        }
    }

    @Output() newCoorinatesSelected: EventEmitter<Coordinates> =
        new EventEmitter<Coordinates>();

    @Output() mapInitialized: EventEmitter<null> =
        new EventEmitter<null>();

    mapDraw: any;

    constructor() { }

    ngOnInit() {

        this.createMapDrawObject();

        this.mapDraw.init("map");

        if (this.selectEnabled) {
            this.mapDraw.enableSelect();
        }

        this.mapDraw.mapOutput.on('singleclick', evt => {
            var newCoordinates = ol.proj.transform(evt.coordinate, 'EPSG:3857', 'EPSG:4326');
            this.newCoorinatesSelected.emit({
                longitude: newCoordinates[0],
                latitude: newCoordinates[1],
                accuracy: 0,
                altitude: 0,
                altitudeAccuracy: 0,
                heading: 0,
                speed: 0
            })
        })

        this.initialized = true;
        this.mapInitialized.emit();
    }

    reDrawPoints() {
        if (this.initialized) {
            for (let coordinates of this.coordinatesList) {
                this.mapDraw.drawPoint(coordinates.longitude, coordinates.latitude);
            }
        }
    }

    createMapDrawObject() : void {
        this.mapDraw = {

            getPointFromLongLat: function (long, lat) {
                return ol.proj.transform([long, lat], 'EPSG:4326', 'EPSG:3857');
            },

            enableSelect: function () {
                this.selectEnabled = true;
            },

            disableSelect: function () {
                this.selectEnabled = false;
            },

            mapOutput: null,

            init: function (target) {
                var obj = this;

                var features = [
                    //new ol.Feature(new ol.geom.Point(getPointFromLongLat(19.008336, 50.135939))),
                    //new ol.Feature(new ol.geom.Point(getPointFromLongLat(19.008336, 50.335939)))
                ];


                obj.source = new ol.source.Vector({
                    features: features
                });

                var clusterSource = new ol.source.Cluster({
                    distance: parseInt('40', 10),
                    source: obj.source
                });

                var styleCache = {};
                var clusters = new ol.layer.Vector({
                    source: clusterSource,
                    style: function (feature) {
                        var size = feature.get('features').length;
                        var style = styleCache[size];
                        if (!style) {
                            style = new ol.style.Style({
                                image: new ol.style.Circle({
                                    radius: 10,
                                    stroke: new ol.style.Stroke({
                                        color: '#fff'
                                    }),
                                    fill: new ol.style.Fill({
                                        color: '#3399CC'
                                    })
                                }),
                                text: new ol.style.Text({
                                    text: size.toString(),
                                    fill: new ol.style.Fill({
                                        color: '#fff'
                                    })
                                })
                            });
                            styleCache[size] = style;
                        }
                        return style;
                    }
                });

                var raster = new ol.layer.Tile({
                    source: new ol.source.OSM()
                });

                var map = new ol.Map({
                    layers: [raster, clusters],
                    target: target,
                    view: new ol.View({
                        center: obj.getPointFromLongLat(19.019987, 50.119271),
                        zoom: 12
                    })
                });

                obj.mapOutput = map;

                map.on('singleclick', function (evt) {

                    if (obj.selectEnabled) {
                        var newCoordinates = ol.proj.transform(evt.coordinate, 'EPSG:3857', 'EPSG:4326');
                        var newFeature = new ol.Feature(new ol.geom.Point(obj.getPointFromLongLat(newCoordinates[0], newCoordinates[1])));
                        obj.source.clear();
                        obj.source.addFeature(newFeature);
                    }
                });
            },

            newCoordinatesAddRegister: function (newCoorinatesAddedCallback) {
                this.newCoorinatesAddedRegisteredCallback = newCoorinatesAddedCallback;
            },

            drawPoint: function (longitude, latitude) {
                var obj = this;
                var newFeature = new ol.Feature(new ol.geom.Point(obj.getPointFromLongLat(Number(longitude), Number(latitude))));
                obj.source.clear();
                obj.source.addFeature(newFeature);

                //if (obj.newCoorinatesAddedRegisteredCallback) {
                //    obj.newCoorinatesAddedRegisteredCallback(newCoordinates);
                //}
            }
        };
    }


}

